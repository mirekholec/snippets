// zrušení proměnné testu
pm.collectionVariables.unset("Registration.Id");

// nastavení proměnné testu
pm.test("Vráceno ID nové registrace kurzu", function () {
    var jsonData = pm.response.json();
    pm.expect(jsonData).to.have.property('id');
    pm.collectionVariables.set("Registration.Id", jsonData.id);
});

// ověření status code
pm.test("Status code je 201 - Created", function () {
    pm.response.to.have.status(201);
});