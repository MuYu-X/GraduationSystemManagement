`C#` `ManagementSystem` `SQL Server` 
# GraduationSystem

Undergraduate graduation project, management system written in C#+SQL server,
but it should be changed and can be made into other things, 
and it is also okay to deal with some homework or design homework.

本科毕业设计，C#+SQL server 写的管理系统，不过应该改改还可以做成其他的，应付一下有些作业或者设计作业也还可以。


The first time I wrote a simple and complete project, it was pretty good, 
and some training courses took this directly as classroom content,
but the first time I realized it by myself, it was quite fulfilling.

第一次写的简单完整的项目，挺菜的，一些培训班都把这个直接当作课堂内容讲了，不过第一次自己一个人实现还是挺有成就感。



### tips
There are too many names in it, and sometimes it is replaced with Chinese Pinyin, but not many, 
it can still be understood, but it just takes some time.

里面命名太多了，所有有时候会用汉语拼音代替，不过不是很多，还是可以看得懂的，不过只是需要花一些时间。

I think of extra tips and then add in
额外的tips想到了再加

# Database Design

LoginDB 用户信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
| UserID |	User ID(用户ID) |	Int	| not(不允许) |	key |
| UserName | User Name(用户名称) |	varchar(50) |	not(不允许)t |	 
| UserPwd |	User Password(用户密码) |	varchar(50) |	not(不允许)	|  

FacultyDB 教学单位信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|FacultyID	|Faculty ID	|Int|	not(不允许)|	主键|
|FacultyName	|Faculty Name	|varchar(50)|	empty(允许)	|外键|

ProfessionDB 专业名称信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|ProfessionID	|专业ID	|Int|	not(不允许)	|主键|
|ProfessionName	|专业名称	|varchar(50)|	empty(允许)|	外键|
|FacultyName|	教学单位名称|	varchar(50)	|empty(允许)|	外键|

TrainPlanDB 专业培养方案信息表信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|TrainingObjectID	|培养目标ID|	Int|	not(不允许)|	主键|
|Faculty|	教学单位名称	|varchar(50)|	empty(允许)	|外键|
|Profession|	专业名称	|varchar(50)	|empty(允许)|	外键|
|TrainingObject|	培养计划|	Text	empty(允许)	|
|GraduationReq1|  毕业要求1|	Text|	empty(允许)	|
|GraduationReq2|	毕业要求2|	Text|	empty(允许)	|
|GraduationReq3|	毕业要求3|	Text|	empty(允许)	|
|GraduationReq4|	毕业要求4|	Text|	empty(允许)	|
|GraduationReq5|	毕业要求5|	Text|	empty(允许)	|
|GraduationReq6|	毕业要求6|	Text|	empty(允许)	|
|GraduationReq7|	毕业要求7|	Text|	empty(允许)	|
|GraduationReq8|	毕业要求8|	Text|	empty(允许)	|
|GraduationReq9|	毕业要求9|	Text|	empty(允许)	|
|GraduationReq10|	毕业要求10|	Text|	empty(允许)  |	
|GraduationReq11|	毕业要求11|	Text|	empty(允许)	|
|GraduationReq12|	毕业要求12|	Text|	empty(允许)	|

CourseMatrixDB 支撑课程评价信息表
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|CourseID	|课程ID|	Int|	not(不允许)	|主键|
|ProfessionName|	专业名称|	varchar(50)|	empty(允许)|	外键|
|FacultyName|	教学单位| varchar(50)|	empty(允许)|	外键|
|CourseName|	课程名称|	varchar(30)|	empty(允许)|	外键|
|GraReq1|	毕业要求1|	varchar(1)|	empty(允许)	|
|GraReq2|	毕业要求2|	varchar(1)|	empty(允许)	|
|GraReq3|	毕业要求3|	varchar(1)|	empty(允许)	|
|GraReq4|	毕业要求4|	varchar(1)|	empty(允许)	|
|GraReq5|	毕业要求5|	varchar(1)|	empty(允许)	|
|GraReq6|	毕业要求6|	varchar(1)|	empty(允许)	|
|GraReq7|	毕业要求7|	varchar(1)|	empty(允许)	|
|GraReq8|	毕业要求8|	varchar(1)|	empty(允许)	|
|GraReq9|	毕业要求9|	varchar(1)|	empty(允许)	|
|GraReq10|	毕业要求10|	varchar(1)|	empty(允许)	|
|GraReq11|	毕业要求11|	varchar(1)|	empty(允许)	|
|GraReq12|	毕业要求12|	varchar(1)|	empty(允许)	|

GraReq1DB 毕业要求指标点
| filed name(字段名称)   | filed description(字段描述)   | filed type(字段类型)   | Empty or not(允许为空)   | Key    |
|:----------------:|:----------------:|:----------------:|:----------------:|:----------------:|
|FacultyName|	教学单位|	varchar(50)|	not(不允许)|	外键|
|ProfessionName| 	专业名称|	varchar(50)|	not(不允许)|	外键|
|GraPoint|	毕业指标点	|Varchar(800)|	not(不允许)|	主键|
|SupportCourse1|	支撑课程1|	varchar(50)|	empty(允许)	|
|SupportWeight1|	支撑权重1|	varchar(10)|	empty(允许)	|
|SupportCourse2|	支撑课程2|	varchar(50)|	empty(允许)	|
|SupportWeight2|	支撑权重2|	varchar(10)|	empty(允许)	|
|SupportCourse3|	支撑课程3|	varchar(50)|	empty(允许)	|
|SupportWeight3|	支撑权重3|	varchar(10)|	empty(允许)	|
|SupportCourse4|	支撑课程4|	varchar(50)|	empty(允许)	|
|SupportWeight4|	支撑权重4|	varchar(10)|	empty(允许)	|
|SupportCourse5|	支撑课程5|	varchar(50)|	empty(允许)	|
|SupportWeight5|	支撑权重5|	varchar(10)|	empty(允许)	|
|SupportCourse6|	支撑课程6|	varchar(50)|	empty(允许)	|
|SupportWeight6|	支撑权重6|	varchar(10)|	empty(允许)	|
|SupportCourse7|	支撑课程7|	varchar(50)|	empty(允许)	|
|SupportWeight7|	支撑权重7|	varchar(10)|  empty(允许)	|
|SupportCourse8|	支撑课程8|	varchar(50)|  empty(允许)	|
|SupportWeight8|	支撑权重8|	varchar(10)|	empty(允许)	|
|RelateCourse|	相关课程|	varchar(200)|	empty(允许)	|





![image](https://github.com/MuYu-X/GraduationSystemManagement/blob/main/E-R%20Diagram.png)
![image](https://github.com/MuYu-X/GraduationSystemManagement/blob/main/relation%20table.png)

[back to the top(回到顶部)](#readme)



