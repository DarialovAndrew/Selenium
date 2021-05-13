Feature: EPAM website


  Scenario: Getting expected page
    Given I am on any page of https://www.epam.com/
    When I click button to get to the work page
    Then I should be redirected to the work page 

  Scenario: Getting contacts 
    Given I am on any page of https://www.epam.com/
    When I click contact us button 
    Then I should get address and phone in which I am interested 

  Scenario:  Getting expected search results
    Given I am on any page of https://www.epam.com/
    When I search for some information 
    Then I should get all information available 

  Scenario: Getting expected language  
    Given I am on the main page
    When I click button for chacnging language 
    Then I should see that page in another language 

  Scenario: Getting share price 
    Given I am on the main page 
    When I click on the Invesors button
    Then I should see all information for investors 

   Scenario: Getting expected page
    Given I am on any page of https://www.epam.com/
    When I click button to get to the telescope page
    Then I should be redirected to the telescope page 

   Scenario: Getting expected page
    Given I am on any page of https://www.epam.com/
    When I click button to get to the open source page
    Then I should be redirected to the open source page 

   Scenario: Getting expected page
    Given I am on any page of https://www.epam.com/
    When I click button to get to the privacy policy page
    Then I should be redirected to the privacy policy page 