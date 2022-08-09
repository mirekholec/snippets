-- přepnutí do single user módu (drop connections) a drop
alter database zak set single_user with rollback immediate
drop database zak