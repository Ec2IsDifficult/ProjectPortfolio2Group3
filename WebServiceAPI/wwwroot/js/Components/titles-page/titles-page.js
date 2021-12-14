define(["knockout", "dataservice"],
    function (ko, ds) {
return function(params) {
    let selectedTitle = ko.observable('tt1954874');
    
    let cast = ko.observable([]);
    let getCast = () => {

            ds.getCast(selectedTitle(),function(data) {
                console.log(data.cast);
                cast(data.cast);
            })};
      
    let titleRating = ko.observable();
    let checkVotes = ko.observable('False');

    let getTitleRating = () => {
        ds.getTitleRating(selectedTitle(), function (data) {
            if(data.numVotes > 0){
                checkVotes('True');
            }
            console.log(data);
            titleRating(data);
        })
    };

    let crew = ko.observable([]);

    let getTitleCrew = async () => {
        await ds.getCrew(selectedTitle(), function (data) {
            console.log(data.crew)
            crew(data.crew);
        })
    };

    let title = ko.observable();
    let getSingleTitle = async () => {
        await ds.getTitle(selectedTitle(), async function (data) {
            console.log(data);
            title(data);
            if (data.awards !== null) {
                await getTitlePoster(data.awards);
            }
        })
    };

    let getTitlePoster = async (_url) => {
        await ds.getPoster(_url);
    };
    
    
    return {
        selectedTitle,
        titleRating,
        getTitleRating,
        crew,
        getTitleCrew,
        title,
        getSingleTitle,
        cast,
        getCast,
        checkVotes,
        getTitlePoster
    }
    }})