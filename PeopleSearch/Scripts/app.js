function PeopleViewModel() {

    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI 
    self.Id = ko.observable("");
    self.FirstName = ko.observable("");
    self.LastName = ko.observable("");
    self.Address = ko.observable("");
    self.Age = ko.observable("");
    self.Interests = ko.observable("");
    self.Picture = ko.observable("");
    self.fileName = ko.observable("");
    
    var People = {
        Id: self.Id,
        FirstName: self.FirstName,
        LastName: self.LastName,
        Address: self.Address,
        Age: self.Age,
        Interests: self.Interests,
        Picture: self.Picture
    };

    self.People = ko.observable();
    self.allPeople = ko.observableArray(); // Contains the list of all people
    self.SearchString = ko.observable(""); //defines the search field
    self.isSearching = ko.observable(); //defines a flag for the animated gears on searching
    self.error = ko.observable();



    // Initialize the view-model
    $.ajax({
        url: '/api/People',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.allPeople(data); //Put the response in ObservableArray
        }
    });

    self.updateSearch = function () {
        var searchString = self.SearchString();
        self.isSearching(true); //the the searching icon
        $.ajax({
            url: '/api/Search/' + searchString,
            cache: false,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: {},
            success: function (data) {
                self.allPeople(data); //Put the response in ObservableArray
                self.isSearching(false); //disable the searching icon. 
            }
        });
    }

    //Add New Item
    self.create = function () {
        // var newRecord = new people(item);


        //addPeople(item);
        if (People.FirstName() != "") {
            $.ajax({

                url: '/api/People/',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(People),
                success: function (data) {
                    self.allPeople.push(data);
                    self.FirstName("");
                    self.LastName("");
                    self.Address("");
                    self.Age("");
                    self.Interests("");
                }
            }).fail(
            function (xhr, textStatus, err) {
                alert(err);
            });
            self.People(null);

        }
        else {
            alert('First name required');
        }
    }

    self.newPeople = function () {
        self.People(People);
        self.Id(0);
    }

    // Edit person data
    self.edit = function (People) {
        alert('action not implemented');

    }
}
var viewModel = new PeopleViewModel();
ko.applyBindings(viewModel);

viewModel.SearchString.subscribe(function () {
    viewModel.updateSearch();
});