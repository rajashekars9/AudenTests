Feature: ShortTermLoan
	As a short term Loan applicant 
	I should be able to select Loan amount and repayment date	

@AudenTests
Scenario: Loan Amount slider display
	Given I launch Auden Short term loan page
	Then Short term loan page should be displayed with Loan amount section
	And default loan amount value should be set to '£400'
	
@AudenTests
Scenario: Loan slider Min-Max Amounts
	Given I launch Auden Short term loan page
	Then Short term loan page should be displayed with Loan amount section
	And minimum and maximum loan amount range should be '£200 - £1000'
	
@AudenTests
Scenario: Update Default slider Loan amount
	Given I launch Auden Short term loan page
	And I edit default loan amount by clicking on the slider
	Then loan amount on slider should be updated

@AudenTests
Scenario: Loan Repayment as weekday
	Given I launch Auden Short term loan page
	When I expand repayment day and select repayment date as '13'
	Then First repayment text should be set to "Friday 13 Dec 2019"

@AudenTests
Scenario: Loan Repayment as weekend
	Given I launch Auden Short term loan page
	When I expand repayment day and select repayment date as '14'
	Then First repayment text should be set to "Friday 13 Dec 2019"
	


