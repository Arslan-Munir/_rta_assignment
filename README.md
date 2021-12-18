# Docs

Dotnet Core 3.1

------------------------------------------------------------------------------------------------------------------------
========================================================================================================================
Entity Framework from src folder (CLI/Terminal):
    Must have ef tools installed globally. (dotnet tool install --global dotnet-ef)
    
    Working with Migrations for Identity project:
    
        > cd RtaAssignment.Identity
    
        Add: 
            > dotnet ef migrations add "Initial_Schema" --startup-project ../RtaAssignment.API
            
        Remove:
            > dotnet ef migrations remove --startup-project ../RtaAssignment.API
         
        Update:
            > dotnet ef database update --startup-project ../RtaAssignment.API
            
========================================================================================================================
------------------------------------------------------------------------------------------------------------------------
