DO $$
    DECLARE
        "@total" INTEGER := 0;

    BEGIN
        SELECT COUNT(*) INTO "@total" FROM public.user_statuses;

        IF "@total" > 0 THEN
            RAISE NOTICE 'Some user statuses already exist.';
        ELSE
            RAISE NOTICE 'Adding statuses!';
		        INSERT INTO
		            public.user_statuses (status)
		            VALUES ('Active'), ('In-active');
		END IF;
    END
$$;