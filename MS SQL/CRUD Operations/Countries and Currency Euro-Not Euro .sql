USE Geography

SELECT CountryName, CountryCode,
CASE 
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
END AS Curenccy
	FROM Countries
	ORDER BY CountryName ASC