#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
RUN apt update
RUN apt upgrade -y
RUN	apt install -y apt-utils
RUN apt install -y libaio1 unzip 

ARG ORA_CLIENT_ZIP_FILENAME=instantclient-basiclite-linux.x64-21.11.0.0.0dbru.zip
ARG ORA_SQLPLUS_ZIP_FILENAME=instantclient-sqlplus-linux.x64-21.11.0.0.0dbru.zip
ARG ORA_CLIENT_FILEPATH=./oracle


ARG ORA_CLIENT_VERSION=21_11

RUN mkdir -p /opt/oracle/network/admin
WORKDIR	/opt/oracle
COPY $ORA_CLIENT_FILEPATH/$ORA_CLIENT_ZIP_FILENAME /opt/oracle/
RUN unzip $ORA_CLIENT_ZIP_FILENAME && rm $ORA_CLIENT_ZIP_FILENAME

COPY $ORA_CLIENT_FILEPATH/$ORA_SQLPLUS_ZIP_FILENAME /opt/oracle/
RUN unzip $ORA_SQLPLUS_ZIP_FILENAME && rm $ORA_SQLPLUS_ZIP_FILENAME

RUN echo /opt/oracle/instantclient_$ORA_CLIENT_VERSION > /etc/ld.so.conf.d/oracle-instantclient.conf
RUN ldconfig

WORKDIR /opt/oracle/network/admin
COPY $ORA_CLIENT_FILEPATH/network/admin/* /opt/oracle/instantclient_$ORA_CLIENT_VERSION/network/admin/
ENV ORACLE_HOME=/opt/oracle/instantclient_$ORA_CLIENT_VERSION

RUN mkdir -p /opt/keys
WORKDIR /app
EXPOSE 80
EXPOSE 443




FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN apt update
RUN apt upgrade -y 
RUN	apt install -y apt-utils curl 
RUN curl -sL https://deb.nodesource.com/setup_18.x | bash -
RUN apt install -y nodejs 
WORKDIR /src
COPY ["mqtt-dynsec-manager/mqtt-dynsec-manager.csproj", "mqtt-dynsec-manager/"]
RUN dotnet restore "mqtt-dynsec-manager/mqtt-dynsec-manager.csproj"
COPY . .
WORKDIR "/src/mqtt-dynsec-manager"
RUN dotnet build "mqtt-dynsec-manager.csproj" -c Release -o /app/build



FROM build AS publish
RUN dotnet publish "mqtt-dynsec-manager.csproj" -c Release -o /app/publish /p:UseAppHost=false




FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mqtt-dynsec-manager.dll"]