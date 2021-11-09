# set base image
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

# set working directory
WORKDIR /app

# copy projects into working directory
COPY *.sln ./
COPY Business/*.csproj Business/
COPY Data/*.csproj Data/
COPY Models/*.csproj Models/
COPY UnitTest/*.csproj UnitTest/
COPY Web/*.csproj Web/

# build projects
RUN cd Web && dotnet restore

# copy src files
COPY . ./

# run shell to check if it worked
# CMD /bin/bash

# publish app
RUN dotnet publish Web -c Release -o Releases --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

WORKDIR /app
COPY --from=build /app/Releases ./
CMD ["dotnet", "Web.dll"]

# docker build -t mason/storemanagermvc:1.0 .
# docker run -d -p 5001:80 -t mason/storemanagermvc:1.0