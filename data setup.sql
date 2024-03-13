insert into Courses
values ('Beginner Guitar', 'Beginner', 'Basic Guitar Course for Beginners.', 1, 1);

insert into Instructors
values ('Expert', 'NAIT', 'test@nait.ca', '12345', 1, 1);

insert into Instruments values ('Guitar');


select * From Instruments;
alter table instruments
add  InstrumentType nvarchar(30) not null;

select * From Courses;

insert into Courses
values ('Intermediate Guitar', 'Intermediate', 'Guitar Course for Experienced Guitarists.', 1, 1);


insert into Courses
values ('Advanced Guitar', 'Advanced', 'Guitar Course for Advanced Guitarists.', 1, 1);