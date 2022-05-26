FROM microsoft/dotnet

WORKDIR /app

COPY EyeTech.Shipped.Api/ ./arquivos

RUN cd arquivos/EyeTech.Shipped.Api/ && dotnet restore

COPY . ./arquivos

RUN mkdir /app/uploads/ && mkdir /app/uploads/veiculos
RUN cd arquivos/EyeTech.Shipped.Api/ && dotnet publish -c Release -o ../../..
RUN rm -rf arquivos && ls && chmod -R 644 /app/uploads

EXPOSE 5001

ENTRYPOINT ["dotnet", "EyeTech.Shipped.Api.dll"]