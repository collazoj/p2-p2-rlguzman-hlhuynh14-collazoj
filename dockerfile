FROM mcr.microsoft.com/dotnet/core/sdk as build
WORKDIR /aspnet
COPY . .
RUN dotnet build BudgetMe.DomainTest/BudgetMe.Domain.csproj
RUN dotnet publish --no-restore -c Release -o out BudgetMe.DomainTest/BudgetMe.Domain.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /dist
COPY --from=build /aspnet/out .

CMD [ "dotnet", "BudgetMe.Domain.dll" ]

