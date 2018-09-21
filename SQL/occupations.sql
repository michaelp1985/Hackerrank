-- Please visit the link below to see a detailed description of the challenge.
-- https://www.hackerrank.com/challenges/occupations/problem

select min(Doctor), min(Professor), min(Singer), min(Actor)
from(
    select ROW_NUMBER() OVER(PARTITION by doctor, professor, singer, actor order by name asc) as rowNumber,
    case when Doctor=1 then name else null end as Doctor,
    case when Professor=1 then name else null end as Professor,
    case when Singer=1 then name else null end as Singer,
    case when Actor=1 then name else null end as Actor
    from occupations
    pivot(
      count(occupation)
        for occupation in(Doctor,Professor,Singer,Actor)) as n
    ) temp
