How to run:-
1. Project created on .NET 6.0.
2. The file names for the 2 provided files are being passed as command line agruements so you need to just simply run the application in Debug(with debugging) or Release(without debugging) mode in Visual Studio 2022 to get the output results automatically.
3. You can also run the application by publishing the app and running the .exe with command line arguements specifically passed.

Approach Used :-
1. Implemented the repository pattern here in the solution. Made a generic repository as abstract repo to provide basic CRUD methods to all repositories that inherit it, all methods open to override for custom implementations.
2. Made Dummy in memory generic object data list in repository to simulate DB table to perform CRUD operations upon.
3. Implemented interface design pattern for different data parsers to help in future extensibility.
4. Implemened interface design pattern in Data Write mechanism to allow future extensibility to other types of databases.
5. Use of AutoMapper for mapping from different response objects to single destination DB object.
6. Use of Generic Design Entity to act as base class for all other DB entities to get common properties like Id, DateCreated, DateModified across all.
7. Written some unit tests using NUnit framework for Database Write and Repository CRUD operations. If more time was alloted, would have written more units including tests for parsers workflow.
8. Given the time constraints, have tried best to use SOLID principles everywhere with focus on Code Segregation, Interface Segregation, use of Generic Types and Abstract Classes.
9. Followed structuring of Projects in solutions into folder structure and use of Solution items in solution.
10. Project is heavily open to extension and prevents modification of existing code, due to use of segregated intefaces. Only during consumption at client side in Program, do we resolve all dependencies based on input by user.
11. There is scope of improvement in the dependency resolution part which can be moved to different class as DependencyResolver. Lack of time didn't let do more such small optimizations.
12. I have Implemented exception handling as and wherever needed.
13. I have created path helper to resolve file path names.
14. The output is as intended and mentioned in the requirements Readme file:

E.g.=>

Output:- 

Parsing files:

Import: D:\Data_Reader_Writer\Solution Items\feed-products\capterra.yaml

importing: Name: 'GitGHub'; Categories: 'Bugs & Issue Tracking,Development Tools'; Twitter: '@github'

importing: Name: 'Slack'; Categories: 'Instant Messaging & Chat,Web Collaboration,Productivity'; Twitter: '@slackhq'

importing: Name: 'JIRA Software'; Categories: 'Project Management,Project Collaboration,Development Tools'; Twitter: '@jira'

Import: D:\Data_Reader_Writer\Solution Items\feed-products\softwareadvice.json

importing: Name: 'Freshdesk'; Categories: 'Customer Service,Call Center'; Twitter: '@freshdesk'

importing: Name: 'Zoho'; Categories: 'CRM,Sales Management'; Twitter: ''
