Feature: RestaurantCheckoutSystem
As a restaurant worker
 I want my ordering system to accuratley calculate bills
 So that customers are chared the correct ammount

 @Scenario1
  Scenario: Standard order creation before 19:00
    Given I have added a Starter at 18:00 with quantity 4
    And I have added 4 Mains at 18:00
    And I have added 4 Drinks at 18:00
    When I calculate the final bill
    Then the final total should be £55.40

  @Scenario1   
  Scenario: Standard order creation after 19:00
    Given I have added a Starter at 18:00 with quantity 4
    And I have added 4 Mains at 18:00
    And I have added 4 Drinks at 19:00
    When I calculate the final bill
    Then the final total should be £58.40

 @Scenario2
  Scenario: A standard order is parially placed before 19:00 and updated after 19:00
    Given I have added a Starter at 18:00 with quantity 1
    And I have added 2 Mains at 18:30
    And I have added 2 Drinks at 18:30
    And I calculate the current the bill
    And the total should be £23.30
    And I have added 2 Mains at 20:00
    And I have added 2 Drinks at 20:00
    When I calculate the final bill
    Then the final total should be £43.70

 @Scenario3
  Scenario: An order is placed before 19:00 and partially cancelled
    Given I have added a Starter at 18:00 with quantity 1
    And I have added 4 Mains at 18:00
    And I have added 4 Drinks at 18:00
    And I calculate the current the bill
    And the total should be £42.2
    And I remove 1 Starter
    And I remove 1 Main
    And I remove 1 Drink
    When I calculate the final bill
    Then the final total should be £28.35
 
 @Scenario3
 Scenario: An order is placed after 19:00 and partially cancelled
    Given I have added a Starter at 20:00 with quantity 1
    And I have added 4 Mains at 20:00
    And I have added 4 Drinks at 20:00
    And I calculate the current the bill
    And the total should be £45.2
    And I remove 1 Starter
    And I remove 1 Main
    And I remove 1 Drink
    When I calculate the final bill
    Then the final total should be £30.6

    # additional scenarios for drinks only orders - ensure no service charge incurred
  @AdditionalScenarios_drinksonly
  Scenario: Drinks only order creation before 19:00
    Given I have added 4 Drinks at 18:00
    When I calculate the final bill
    Then the final total should be £7.00

@AdditionalScenarios_drinksonly
  Scenario: Drinks only order creation after 19:00
    Given I have added 4 Drinks at 20:00
    When I calculate the final bill
    Then the final total should be £10.00

@AdditionalScenarios_drinksonly
 Scenario: Drinks only order creation before 19:00 with amendment afer 19:00
    Given I have added 4 Drinks at 18:00
    And I calculate the current the bill
    And the total should be £7.00
    And I have added 2 Drinks at 20:00
    When I calculate the final bill
    Then the final total should be £12.00

