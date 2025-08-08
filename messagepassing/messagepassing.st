"Transcript is like the console for displaying output"
Transcript show: 'Let''s explore message passing in Pharo!'.
Transcript cr. "Adds a newline"

"--- Class Definition for Person ---"
Object subclass: #Person
	instanceVariableNames: 'name age' "Instance variables to hold the person's name and age"
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Examples'.

"--- Methods for initializing Person objects ---"
!Person methodsFor: 'initialization'!

initialize: aName age: anAge
	"This method is called when a new Person object is created.
	It sets the initial values for the name and age."
	name := aName.
	age := anAge.! !

"--- Methods for accessing the Person's attributes ---"
!Person methodsFor: 'accessing'!

age
	"Returns the age of the person."
	^ age!

name
	"Returns the name of the person."
	^ name! !

"--- Method for the Person to greet ---"
!Person methodsFor: 'greeting'!

greet
	"Displays a greeting message to the Transcript, including the person's name and age."
	Transcript show: 'Hello, my name is ', name, ' and I am ', age asString, ' years old.'; cr.! !

"--- Class Definition for Messenger ---"
Object subclass: #Messenger
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Examples'.

"--- Method for the Messenger to send a message ---"
!Messenger methodsFor: 'sending'!

sendMessage: aString to: aPerson
	"This method simulates sending a message to a Person object.
	It displays a message in the Transcript indicating what is being sent and to whom,
	and then it sends the 'receiveMessage:from:' message to the target Person."
	Transcript show: 'Sending message "', aString, '" to ', aPerson name, '.'; cr.
	aPerson receiveMessage: aString from: self.! !

"--- Method for the Person to receive a message ---"
!Person methodsFor: 'receiving'!

receiveMessage: aString from: aSender
	"This method is called when a Person object receives a message.
	It displays a message in the Transcript indicating who received the message,
	what the message was, and who sent it."
	Transcript show: name, ' received message "', aString, '" from a Messenger.'; cr.! !

"--- Creating instances of Person and Messenger ---"
john := Person new initialize: 'John' age: 30.
jane := Person new initialize: 'Jane' age: 25.
messenger := Messenger new.

"--- Sending messages using the Messenger ---"
messenger sendMessage: 'How are you?' to: john.
messenger sendMessage: 'Nice to meet you!' to: jane.

"--- Asking the Person objects to greet ---"
john greet.
jane greet.