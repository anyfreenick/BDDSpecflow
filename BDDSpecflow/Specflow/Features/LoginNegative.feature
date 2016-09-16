Feature: LoginNegative
	As a user I would like to be sure that it is not possible to Sing In if login or pssword is empty

@LoginNegative
Scenario Outline: Sing In with empty field

Given 	Ebay Sign In page is open
When 	I set Account "<account>"
And     I set Password "<psw>"
And     I click SignIn button
Then    I get error "<message>"

Examples:
|account		       |psw	|message					      |
|			           |	|К сожалению, данные не совпадают.|
|shaforost.olya@mail.ru|	|К сожалению, данные не совпадают.|
|			           |abc	|К сожалению, данные не совпадают.|