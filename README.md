`C#` `ManagementSystem` `SQL Server` 
# GraduationSystem

Undergraduate graduation project, management system written in C#+SQL server,
but it should be changed and can be made into other things, 
and it is also okay to deal with some homework or design homework.

本科毕业设计，C# Winform + SQL server 写的管理系统，不过应该改改还可以做成其他的，应付一下有些作业或者设计作业也还可以。


The first time I wrote a simple and complete project, it was pretty good, 
and some training courses took this directly as classroom content,
but the first time I realized it by myself, it was quite fulfilling.

第一次写的简单完整的项目，挺菜的，一些培训班都把这个直接当作课堂内容讲了，不过第一次自己一个人实现还是挺有成就感。

In the source code , I implement add , delete , modify and check ,
also the program can also output PDF files with database information
在源码中，我实现了对于数据库的增删改查以及导出PDF文件

### tips
There are too many names in it, and sometimes it is replaced with Chinese Pinyin, but not many, 
it can still be understood, but it just takes some time.

里面命名太多了，所有有时候会用汉语拼音代替，不过不是很多，还是可以看得懂的，不过只是需要花一些时间。

I think of extra tips and then add in
额外的tips想到了再加

# Database Design

## LoginDB 用户信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
| UserID |	User ID(用户ID) |	Int	| not(不允许) |	primary key(主键) |
| UserName | User Name(用户名称) |	varchar(50) |	not(不允许) |	 
| UserPwd |	User Password(用户密码) |	varchar(50) |	not(不允许)	|  

## FacultyDB 教学单位信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|FacultyID	|Faculty ID(教学单位ID)	|Int|	not(不允许)|	primary key(主键)|
|FacultyName	|Faculty Name(教学单位名称)	|varchar(50)|	empty(允许)	|foreign key(外键)|

## ProfessionDB 专业名称信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|ProfessionID	| Profession ID(专业ID)	|Int|	not(不允许)	|primary key(主键)|
|ProfessionName	| Profession Name(专业名称)	|varchar(50)|	empty(允许)|	foreign key(外键)|
|FacultyName|	Faculty Name(教学单位名称) | 	varchar(50)	|empty(允许)|	foreign key(外键)|

## TrainPlanDB 专业培养方案信息表信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|TrainingObjectID	|培养目标ID|	Int|	not(不允许)|	primary key(主键)|
|Faculty|	Faculty Name(教学单位名称)	|varchar(50)|	empty(允许)	|foreign key(外键)|
|Profession|	Profession Name(专业名称)	|varchar(50)	|empty(允许)|	foreign key(外键)|
|TrainingObject|	Training Plan(培养计划)|	Text|	empty(允许)	|
|GraduationReq1|  Graduation Requirement1(毕业要求1)|	Text|	empty(允许)	|
|GraduationReq2|	Graduation Requirement2(毕业要求2)|	Text|	empty(允许)	|
|GraduationReq3|	Graduation Requirement3(毕业要求3)|	Text|	empty(允许)	|
|GraduationReq4|	Graduation Requirement4(毕业要求4)|	Text|	empty(允许)	|
|GraduationReq5|	Graduation Requirement5(毕业要求5)|	Text|	empty(允许)	|
|GraduationReq6|	Graduation Requirement6(毕业要求6)|	Text|	empty(允许)	|
|GraduationReq7|	Graduation Requirement7(毕业要求7)|	Text|	empty(允许)	|
|GraduationReq8|	Graduation Requirement8(毕业要求8)|	Text|	empty(允许)	|
|GraduationReq9|	Graduation Requirement9(毕业要求9)|	Text|	empty(允许)	|
|GraduationReq10|	Graduation Requirement10(毕业要求10)|	Text|	empty(允许)  |	
|GraduationReq11|	Graduation Requirement11(毕业要求11)|	Text|	empty(允许)	|
|GraduationReq12|	Graduation Requirement12(毕业要求12)|	Text|	empty(允许)	|

## CourseMatrixDB 支撑课程评价信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|CourseID	|Course ID(课程ID)|	Int|	not(不允许)	|primary key(主键)|
|ProfessionName|	Profession Name(专业名称)|	varchar(50)|	empty(允许)|	foreign key(外键)|
|FacultyName|	Faculty Name(教学单位名称)| varchar(50)|	empty(允许)|	foreign key(外键)|
|CourseName|	Course Name(课程名称)|	varchar(30)|	empty(允许)|	foreign key(外键)|
|GraReq1|	Graduation Requirement1 level(毕业要求1)|	varchar(1)|	empty(允许)	|
|GraReq2| Graduation Requirement2 level(毕业要求2)|	varchar(1)|	empty(允许)	|
|GraReq3|	Graduation Requirement3 level(毕业要求3)|	varchar(1)|	empty(允许)	|
|GraReq4|	Graduation Requirement4 level(毕业要求4)|	varchar(1)|	empty(允许)	|
|GraReq5|	Graduation Requirement5 level(毕业要求5)|	varchar(1)|	empty(允许)	|
|GraReq6|	Graduation Requirement6 level(毕业要求6)|	varchar(1)|	empty(允许)	|
|GraReq7|	Graduation Requirement7 level(毕业要求7)|	varchar(1)|	empty(允许)	|
|GraReq8| Graduation Requirement8 level(毕业要求8)|	varchar(1)|	empty(允许)	|
|GraReq9|	Graduation Requirement9 level(毕业要求9)|	varchar(1)|	empty(允许)	|
|GraReq10|	Graduation Requirement10 level(毕业要求10)|	varchar(1)|	empty(允许)	|
|GraReq11|	Graduation Requirement11 level(毕业要求11)|	varchar(1)|	empty(允许)	|
|GraReq12|	Graduation Requirement12 level(毕业要求12)|	varchar(1)|	empty(允许)	|

## GraReq1DB 毕业要求指标点
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|FacultyName|	Faculty Name(教学单位名称)|	varchar(50)|	not(不允许)|	foreign key(外键)|
|ProfessionName| 	Profession Name(专业名称)|	varchar(50)|	not(不允许)|	foreign key(外键)|
|GraPoint|	Graduation point(毕业指标点)	|Varchar(800)|	not(不允许)|	primary key(主键)|
|SupportCourse1|	Support Course1(支撑课程1)|	varchar(50)|	empty(允许)	|
|SupportWeight1|	Support Weight1(支撑权重1)|	varchar(10)|	empty(允许)	|
|SupportCourse2|	Support Course2(支撑课程2)|	varchar(50)|	empty(允许)	|
|SupportWeight2|	Support Weight2(支撑权重2)|	varchar(10)|	empty(允许)	|
|SupportCourse3|	Support Course3(支撑课程3)|	varchar(50)|	empty(允许)	|
|SupportWeight3|	Support Weight3(支撑权重3)|	varchar(10)|	empty(允许)	|
|SupportCourse4|	Support Course4(支撑课程4)|	varchar(50)|	empty(允许)	|
|SupportWeight4|	Support Weight4(支撑权重4)|	varchar(10)|	empty(允许)	|
|SupportCourse5|	Support Course5(支撑课程5)|	varchar(50)|	empty(允许)	|
|SupportWeight5|	Support Weight5(支撑权重5)|	varchar(10)|	empty(允许)	|
|SupportCourse6|	Support Course6(支撑课程6)|	varchar(50)|	empty(允许)	|
|SupportWeight6|	Support Weight6(支撑权重6)|	varchar(10)|	empty(允许)	|
|SupportCourse7|	Support Course7(支撑课程7)|	varchar(50)|	empty(允许)	|
|SupportWeight7|	Support Weight7(支撑权重7)|	varchar(10)|  empty(允许)	|
|SupportCourse8|	Support Course8(支撑课程8)|	varchar(50)|  empty(允许)	|
|SupportWeight8|	Support Weight8(支撑权重8)|	varchar(10)|	empty(允许)	|
|RelateCourse|	Relate Course(相关课程)|	varchar(200)|	empty(允许)	|


of course the GraReq1DB SupportCourse and RelateCourse need to compared with CourseMatrixDB CourseName
if there is no CourseName named "math" in CourseMatrixDB , the GraReq1DB should not have it yet.
but I didn't write it , maybe someday i will write the check function and updata the source code.

GraReq1DB里面的支撑课程和相关课程应该在CourseMatrixDB的CourseName与之对应，虽然可以是一对多的关系
比如CourseName没有“math”，那么GraReq1DB里面也不应该出现“math”
但实际上我并没有在源代码中做这一检查，可能以后会写一个check function去检查这个。


![image](https://github.com/MuYu-X/GraduationSystemManagement/blob/main/E-R%20Diagram.png)
![image](https://github.com/MuYu-X/GraduationSystemManagement/blob/main/relation%20table.png)

[back to the top(回到顶部)](#readme)



