# Readme for ARxIUM TestApp
C# Programming assignment for the ARxIUM interview process.

Notes about the implementation:
- WinForms UI application.
- The list of drugs to display is stored in an XML file using serialization. This allows additional drugs to easily be added at run time. 
  If this file does not exist it is automatically created using the 3 drug names specified in the assignment.

- The logger was implemented using the singleton design pattern since logging is typically an application wide requirement.
- The logger uses an `ActionBlock` to queue logs and then write them to the file in an asynchronous manner.

  