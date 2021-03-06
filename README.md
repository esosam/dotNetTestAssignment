# dotNetTestAssignment
dotNet Project Test Assignment

Requirements:
1.	Provide a simple html page in which a user can enter the following.  The page merely needs to be functional and does not need to be styled in any way.
  a.	Last Name
  b.	First Name
  c.	email
2.	When the user submits this data, a confirmation page should be displayed which tells the user the data was received by the system.
3.	All data submitted in this way must be saved, but only for the duration of the application’s run.  It does not need to survive a restart of the application.  However, in your design consider that this application will ultimately have to save this data to a persistent datastore.
4.	A REST endpoint must be provided to retrieve all mailing list entries.  This endpoint should take 2 optional parameters:
  a.	Last name- if specified, only records with this last name are returned
  b.	Ascending/Descending flag which indicates how to sort records.  If not specified, default behavior is to sort ascending.  Records should be sorted by last name.  Where last names are equal, records should be sorted by first name.
5.	At least one automated test must be provided which tests one of your .net components.
6.	Application should run in MS Internet Information Server.
7.	Security is not required for this exercise.


Author
Esteban Sosa - esosa@edksis.com http://edksis.com/

License
this dotNet Project Test Assignment is free and unencumbered public domain software. For more information, see http://unlicense.org/ or the accompanying UNLICENSE file.

I dedicate any and all copyright interest in this software to the
public domain. I make this dedication for the benefit of the public at
large and to the detriment of my heirs and successors. I intend this
dedication to be an overt act of relinquishment in perpetuity of all
present and future rights to this software under copyright law.
