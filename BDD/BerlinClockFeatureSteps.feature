Feature: The Berlin Clock
	As a clock enthusiast
    I want to tell the time using the Berlin Clock
    So that I can increase the number of ways that I can read the time


Scenario: Midnight 00:00
When the time is "00:00:00"
Then the clock should look like
"""
Y
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""


Scenario: Middle of the afternoon
When the time is "13:17:01"
Then the clock should look like
"""
O
RROO
RRRO
YYROOOOOOOO
YYOO
"""

Scenario: Just before midnight
When the time is "23:59:59"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYRYYRYY
YYYY
"""

Scenario: Midnight 24:00
When the time is "24:00:00"
Then the clock should look like
"""
Y
RRRR
RRRR
OOOOOOOOOOO
OOOO
"""

Scenario: MidDay 12:00
When the time is "12:00:00"
Then the clock should look like
"""
Y
RROO
RROO
OOOOOOOOOOO
OOOO
"""

Scenario: MidDay plus 1 second 12:00:01
When the time is "12:00:01"
Then the clock should look like
"""
O
RROO
RROO
OOOOOOOOOOO
OOOO
"""

Scenario: Input is not a valid date/time
When the time is "24:00:01"
Then it should throw an exception

Scenario: Input is not a date
When the time is "bad_value"
Then it should throw an exception