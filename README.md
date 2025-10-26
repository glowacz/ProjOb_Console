# ProjOb_Console

User Console

It allows the user to add, edit, delete, and list objects of type Author, Episode, Series, and Movie.
The objects are interconnected: every Episode, Series, and Movie has an assigned Author, and each Series has multiple Episodes assigned.
Commands are added to a queue, which can be listed, exported to a file, executed, or deleted.
By default, in the main function, R0.Create(), R4.Create(), and CommandMain.Init() are called to populate the collection with example objects, allowing immediate execution of list/find commands.

Additionally, the project includes custom-implemented collections: vector, linked list, and binary tree, enabling:
adding, deleting, and obtaining a forward or backward iterator.
All these collections implement the same interface, for which I developed the following algorithms: Find, Print, ForEach, and CountIf.

The console supports the following commands (content prepared by the course instructors):

**1. list** - prints all objects of a particular type

The format of the command should be as follows:

    list <name_of_the_class>

The command should print to the console all of the objects of this class where printing an object
means listing all of its non reference fields (make sure that the format is readable and not just
blatantly printing the values of all of the fields).

In the future there might be more types so make sure that you account for that.

Example usages:
    list game
    list animal

**2. find** - prints objects matching certain conditions

Find works similarly to ‘list’, but you can also add optional parameters for filtering results. Only
results that fulfil all of the requirements are to be printed.

The format of the command should be as follows:

    find <name_of_the_class> [<requirement> …]

where requirements (space separated list of requirements) specify acceptable values of atomic non
reference fields. They follow format:

    <name_of_field>=|<|><value>

Where “=|<|>” means any strong comparison operator. For numerical fields natural comparison should
be used. Strings should use a lexicographic order. For other types only “=” is allowed. If a value
were to contain spaces it should be placed inside quotation marks.

You should check that the name of the field is correct for the specified class and that the value
can be parsed to the correct type. If there are any errors in the command they should be reported
instead of printing the result of finding.

Usage of Reflection is forbidden.

Everything that was said about “list” is also applicable to “find”.

Example usage:
    find game name=”Elden Ring”

**3. exit** - gracefully finish execution of your application

**4. add** - adds a new object of a particular type.

This command will be unique in a way that it will require the user to enter multiple lines of
additional information before getting fully executed. The format of the first line of the command
should be as follows:

    add <name_of_the_class> base|secondary

where base|secondary defines the representation in which the object should be created. After
receiving the first line the program should present the user with names of all of the atomic non
reference fields of this particular class. The program waits for further instructions from the user
describing the values of the fields of the object that is supposed to be created with the add
command. The format for each line is as follows:

	<name_of_field>=<value>

A line like that means that the value of the field <name_of_field> for the newly created object
should be equal to <value>. The user can enter however many lines they want in such a format (even
repeating the fields that they have already defined - in this case the previous value is overridden)
describing the object until using one of the following commands:

	DONE

or

	EXIT

After receiving the DONE command the creation process should finish and the program should add a new
object described by the user to the collection. After receiving the EXIT command the creation
process should also finish but no new object is created and nothing is added to the collection. The
data provided by the user is also discarded.

Example usages:
    add book base
    [Available fields: 'title, year, pageCount']
    title="The Right Stuff"
    year=1993
    name=abc
    [Some sensible error message]
    DONE
    [Book created]

add book secondary
    [Available fields: "title, year, pageCount"]
    title="The Right Stuff"
    EXIT
    [Book creation abandoned]

Exact look of the prompt and responses is up to the user. If a value for a field was not mentioned
by the user you should provide a default value which makes sense in the context of your assigned
topic.

**5.	edit** <name_of_the_class> [<requirement> …] - edits values of the given record.

This command allows editing a given record if requirement conditions (which work the
same as in the find command) specify one record uniquely. Editing works the same as
adding a new element
	<name_of_field>=<value>
replace the field's old value with a new one until DONE or EXIT is provided. When 
EXIT is chosen, it does not modify any value.

**6.	queue print** – prints all commands currently stored in the queue

This command should print each stored in queue commands its name and all command
parameters in human-readable form.

**7.	queue export** {filename} [format] – exports all commands currently stored in 
the queue to the specified file

This command saves all commands from the queue to the file. There are supported 
two formats "XML" (default) and "plaintext". The structure of XML should contain 
only necessary fields. The plain text format should be the same as it is in the
command line – that means that pasting the content of the file to the console 
should add stored commands.

**8.	queue commit** – execute all commands from the queue

This command executes all commands stored in the queue in order of their 
addition. After that queue should be cleared and proper collection modified.

**9. delete** <name_of_the_class> [<requirement> …] - removes given record from collections.

This command allows deleting a given record if requirement conditions (which work the
same as in the find and edit command) specify one record uniquely.

**10. queue dismiss** - clears command queue

This command clears all commands which are currently stored in the queue.

**11. queue load** {filename} – loads commands to the end of the queue from the given file.

This command loads exported commands saved in a given file to the end of the queue.
The loaded command should be in the same order as they were during exporting.
Both file formats are supported: XML and plain-text.
