@ModelType IEnumerable(Of GroupActivityViewModel)
@Code
    ViewData("Title") = "Home Page"
End Code
<style>

</style>
<div class="jumbotron">
    <h2>Vision</h2>
    <p class="lead">
        Provide a suitable environment to highlight students capabilities through activities that develop their academic and non-academic skills
    </p>
    <h2> message</h2>
    <p class="lead">
        Enhance students' skills in literary,cultural,scientific and social aspects to help them refine their personality
    </p>
</div>
@*Electronic Transactions Team
Responsible for all about the club from
 emails instaqram twitter and other social media.
Registration Team 
Registers the members of the club and the attendees
 posts events workshops and prepare certificates.*@
<div>
    @For Each item In Model
        @<div Class="col-md-6">
            <div Class="panel panel-default center-block">
                <div Class="panel-heading"><a href="#" class="pull-right">
                       <img src="~/img/group.png" /> </a> <h4>@item.Group.Name</h4></div>
                <div Class="panel-body">

                    <div Class="clearfix"></div>
                    @item.Group.Description
                    <ul Class="list-unstyled">
                        @For Each activity In item.Activities
                            @<li>@Html.ActionLink(activity.Name, "Details", "Activities", New With {.id = activity.Id}, Nothing)</li>
                        Next
                    </ul>
                </div>
            </div>
        </div>
    Next
    <div Class="col-md-6">
        <div Class="panel panel-default">
            <div Class="panel-heading"><h4>Book Group</h4></div>
            <div Class="panel-body">
                <p> Interested in activating the role of the book in educating students and support their education.</p>
            </div>
        </div>
    </div>
    <div Class="col-md-6">
        <div Class="panel panel-default">
            <div Class="panel-heading"><h4>Health Group</h4></div>
            <div Class="panel-body">
                <p>  Educating students who care about the health aspects of nutrition safety and public health.</p>
            </div>
        </div>
    </div>
    <div Class="col-md-6">
        <div Class="panel panel-default">
            <div Class="panel-heading"><h4>Arts and Technology Group</h4></div>
            <div Class="panel-body">
                <p>   working to refine the skills of students through art exhibitions workshops in painting, photography, programming and production of documentary films.</p>
            </div>
        </div>
    </div>
    <div Class="col-md-6">
        <div Class="panel panel-default">
            <div Class="panel-heading"><h4>Culture and Theater Group</h4></div>
            <div Class="panel-body">
                <p>   Interested in developing the students culture through the creation of events, lectures and plays that discuss topics that interest students.</p>
            </div>
        </div>
    </div>
    <div Class="col-md-6 center-block">

        <div Class="panel panel-default ">
            <div Class="panel-heading"><h4>Conversation Group </h4></div>
            <div Class="panel-body">
                <p>works to strengthen the students in the field of conversation and dialogue through training on public speaking and debating.</p>
            </div>
        </div>
    </div>
</div>
