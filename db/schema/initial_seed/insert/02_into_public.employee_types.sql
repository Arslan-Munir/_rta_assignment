DO $$
    DECLARE
        "@total" INTEGER := 0;

    BEGIN
        SELECT COUNT(*) INTO "@total" FROM public.employee_types;

        IF "@total" > 0 THEN
            RAISE NOTICE 'Some employee types already exist.';
        ELSE
            RAISE NOTICE 'Adding employee types!';
		        INSERT INTO
		            public.employee_types (name)
		            VALUES ('Contract'), ('Permanent'), ('Retired');
		END IF;
    END
$$;