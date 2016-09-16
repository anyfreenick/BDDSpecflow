Feature: Cart
	As a user I would like to be sure that all chosen items will be set into the cart

@oneitem
Scenario: Put one item into cart
	When Ebay site is open
	And  Jewelry Sets paragraph is opened
	And  Any item is chosen
	And  Information page of the product is opened
	And  Metal color is set
	And  Quantity of the product is 1
	And  The product is added into the cart
    Then There is/are 1 item/items in the cart
	And  Summary Quantity all items in the cart are equals 1

@severalSameItems
Scenario: Put several goods of one name into the cart
	When Ebay site is open
	And  Jewelry Sets paragraph is opened
	And  Any item is chosen
	And  Information page of the product is opened
	And  Metal color is set
	And  Quantity of the product is 3
	And  The product is added into the cart
	Then There is/are 1 item/items in the cart
	And  Summary Quantity all items in the cart are equals 3

@SeveralDifferentItems
Scenario: Put several goods with different names into the cart
	When Ebay site is open
	And  Jewelry Sets paragraph is opened
	And  3 items with different names are added into the cart
	Then There is/are 3 item/items in the cart