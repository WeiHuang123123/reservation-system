CREATE TABLE `employee`(   	-- 所有職員
		`emp_id` INT PRIMARY KEY ,   
        `name` VARCHAR(25)  , 
        `birth_date` DATE DEFAULT NULL,
        `sex` VARCHAR(1) ,
        `salary` INT,
        `branch_id` INT,	-- 因為employee這表格還沒創完 所以不能立刻加foreign  key 
        `sup_id` INT 		-- 需要後來alter設定回來
);
CREATE TABLE `branch`( 		-- 部門&主管
		`branch_id` INT primary key,
		`branch_name` VARCHAR(25) , 
        `manager_id` INT, 		
        foreign key(`manager_id`) references `employee`(`emp_id`) on delete set null
);

-- 補設定 foreign key 
alter table `employee`
add foreign key(`branch_id`)
references `branch`(`branch_id`)
on delete set null;

alter table `employee`
add foreign key(`sup_id`)
references `employee`(`emp_id`)
on delete set null;

CREATE TABLE `client`( 		-- 客戶
		`client_id` INT primary key,
		`client_name` VARCHAR(25) , 
        `phone` VARCHAR(20)		
);
CREATE TABLE `work_with`( 	-- 客戶
		`emp_id` INT ,
		`client_id` INT , 
        `total_sales` INT,
        primary key(`emp_id`,`client_id`), -- 兩個只能額外設定
        foreign key(`emp_id`) references `employee`(`emp_id`) on delete cascade,
        foreign key(`client_id`) references `client`(`client_id`) on delete cascade
);

-- 有foreign key 要先設null 最後再設定回來

