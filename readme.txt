read me

The soultion contians book service project. The odata api works for normal relationship entities but not for contained relation when using with select not having the key column. i.e.

The following is working
~/Entities(EntityID)?$expand=ContainedEntities&$select=Property,EntityID

However the below one does not work
~/Entities(EntityID)?$expand=ContainedEntities&$select=Property

Similarly in this book service project with following data model

Book having normal relationship with author i.e. book.Authors
Book having contianed relationship with comment i.e. book.Comments

The following works
~/Books(1)?$select=Title&$expand=Authors
~/Books(1)?$select=Id,Title&$expand=Authors,Comments

However the below one does not work
~/Books(1)?$select=Title&$expand=Comments
~/Books(1)?$select=Title&$expand=Authors,Comments

TODO: Need to test the same behavior exists in latest verions of OData Api.