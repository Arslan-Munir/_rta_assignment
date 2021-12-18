CREATE TABLE IF NOT EXISTS public.employees(
	id SERIAL PRIMARY KEY,
	name TEXT NOT NULL,
	nationality TEXT NOT NULL,
	designation TEXT NOT NULL,
	mobileNo TEXT NOT NULL,
	email TEXT NOT NULL,
	passportExpireDate DATE NOT NULL,
	passportNo INT NOT NULL,
	typeId SMALLINT NOT NULL,
	
	CONSTRAINT fk_employee_employee_type
				FOREIGN KEY (typeId)
				REFERENCES public.employee_types(id) ON DELETE RESTRICT ON UPDATE CASCADE
);
