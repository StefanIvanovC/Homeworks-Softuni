USE Geography

SELECT c.CountryCode, COUNT(*)
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	WHERE c.CountryCode IN ('US', 'RU', 'BG')
	GROUP BY c.CountryCode