# Restaurant Checkout System Test Notes

## Intro

The aim of this project is to test the various scenarios the restaurant checkout system
detailed in the task brief.

## Test Framework:

This task was intended to be written using SpecFlow for BDD, however this tool has been deprecated as of 
31st December 2024 which resulted in installation issues when attempting to add the specflow extension to the project. 

An alternative tool BDD, ReqNRoll has created by the same team to replace SpecFlow. 
ReqNRoll follows the same BDD/Cucumber format as Specflow and tests are presented and structured in the same way as specflow.

ReqNRoll had been used in this project as an alternative/workaround in order to address the issues detailed above.


## Testing Assumptions

- Order calculations are not affected by group size. As a result, feature files and the associated step definitions only consider the 
category of item, quantity ordered and the time of order.

- It assumed that scenarios 2 and 3 are to be tested as complete workflows. An alternative could be to split them into separate scenarios to test in sequence

- Food Order Adjustments - order adjustment for food items takes into account the 
service charge payable per item amended. 

- Drinks Order Adjustments – order adjustment for drinks takes into account the 
time at which the order was place when calculating the bill. i.e calculations for 
drinks ordered before 19:00 take into account a discounted rate of 30%. All drinks ordered after this time do no have the discounted rate

- Service charge is applied to food items only
