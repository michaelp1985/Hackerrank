-- Please visit the link below to see a detailed description of the challenge
-- https://www.hackerrank.com/challenges/the-company/problem

select c.*, 
count(distinct lm.lead_manager_code) as L, 
count(distinct sm.senior_manager_code) as S,
count(distinct m.manager_code) as M,
count(distinct e.employee_code) as E
from Company c 
inner join Lead_Manager lm on lm.company_code = c.company_code
inner join Senior_Manager sm on sm.lead_manager_code = lm.lead_manager_code
inner join Manager m on m.senior_manager_code = sm.senior_manager_code
inner join Employee e on e.manager_code = m.manager_code
group by c.company_code, c.founder
order by c.company_code
