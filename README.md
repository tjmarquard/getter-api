# getter-api

A pass-through API that hits three api.weather.gov endpoints.
	- /alerts
	- /alerts/active
	- /alerts/types

It could use better unit tests for the WeatherService class since these are hitting the actual endpoints and not a mock. But I've spent enough time on this.

Running locally, the swagger page is here: https://localhost:44375/swagger/index.html