define(["knockout", "dataservice"], function(ko, ds) {
    return function(params)  {
    let selectedPerson = ko.observable();
    
    let personData = ko.observable();
    let getPerson = () => {
        ds.getPerson(selectedPerson(), function (data) {
            console.log(data);
            personData(data);
        })
    };

    let knownFor = ko.observable([]);
    let availableKnownFor = ko.observable();

    let getKnownFor = () => {

        ds.knownFor(selectedPerson(), function (data) {
            console.log(data);
            if (data.length > 0) {
                availableKnownFor('True');
            } else {
                availableKnownFor('False');
            }
            knownFor(data);
        })
    };


    let coActors = ko.observable([]);
    let availableCoActors = ko.observable();

    let getCoActors = () => {

        ds.coactors(selectedPerson(), function (data) {
            console.log(data);
            if (data.length > 0) {
                availableCoActors('True');
            } else {
                availableCoActors('False');
            }
            coActors(data);
        })
    };

    let professions = ko.observable();
    let getPrimeProfessions = () => {
        ds.primeProfessions(selectedPerson(), function (data) {
            console.log(data);
            let jobs = '';
            let i = 0;
            data.forEach(function (job) {
                if (i === (data.length - 1)) {
                    jobs += job.profession;
                } else {
                    jobs += job.profession + ', ';
                    i++;
                }
            });
            professions(jobs);
        })
    }
    
    return {
        selectedPerson,
        getPerson,
        personData,
        knownFor,
        availableKnownFor,
        getKnownFor,
        coActors,
        availableCoActors,
        getCoActors,
        professions,
        getPrimeProfessions
    }
    }
});
        