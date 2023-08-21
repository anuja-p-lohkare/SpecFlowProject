Feature: OrangeHRMLoginFeature

Login to OrangeHRM

@SpecFlowTests
Scenario: Login to OrangeHRM
  Given Navigate to OrangeHRM login page
  When user enters <username> and <password>
  And clicks on Login button
  Then user should be logged in succesfully
Examples:
  | username    | password |
  | Admin    | admin123    |
	
