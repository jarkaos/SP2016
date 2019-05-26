function readRecords() {
    var ctx = SP.ClientContext.get_current();
    var TrainersList = ctx.get_web().get_lists().getByTitle('New Trainers');

    var camlQuery = new SP.CamlQuery();

    camlQuery.set_viewXml('<View><Query><Where><BeginsWith><FieldRef Name=\'Title\'/>' +
        '<Value Type=\'Text\'>M</Value></BeginsWith></Where></Query></View>');

    this.allTrainers = TrainersList.getItems(camlQuery);

    ctx.load(allTrainers);

    ctx.executeQueryAsync(Function.createDelegate(this, this.onSuccess), Function.createDelegate(this, this.onFailure));
}

function onSuccess() {
    var ul = document.getElementById("allTrainers");
    var str = '';
    var TrainersListItemEnum = this.allTrainers.getEnumerator();

    while (TrainersListItemEnum.moveNext()) {
        var oListItem = TrainersListItemEnum.get_current();

        str = 'ID: ' + oListItem.get_id() + ' Title: ' + oListItem.get_item('Title');

        var element = document.createElement('li');
        element.innerText = str;
        ul.appendChild(element);
    }
}

function onFailure(sender, args) {
    alert("Error: " + args.get_message() + "\n" + args.get_stackTrace());
}