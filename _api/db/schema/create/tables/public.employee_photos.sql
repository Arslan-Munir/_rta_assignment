CREATE TABLE IF NOT EXISTS public.employee_photos(
	id SERIAL PRIMARY KEY,
	url TEXT NOT NULL,
    public_id TEXT NULL,
	employee_id INT NOT NULL,
	CONSTRAINT fk_employee_photo_employee
		FOREIGN KEY (employee_id)
			REFERENCES public.employees(id) ON DELETE CASCADE
);
