-- Please visit the link below to see a detailed description of the challenge
-- https://www.hackerrank.com/challenges/the-pads/problem

select name+'('+substring(Occupation, 1, 1)+')' from occupations order by name
go
select 'There are a total of '+ CAST(count(*) AS VARCHAR) + ' ' + Lower(Occupation) + 's.' from occupations group by Occupation order by count(*), occupation
