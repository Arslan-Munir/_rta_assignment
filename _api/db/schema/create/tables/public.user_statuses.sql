
CREATE TABLE IF NOT EXISTS public.user_statuses(
    id SMALLINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY ,
    status TEXT NOT NULL
);