@ModelType IEnumerable(Of Student)

<h2>Members</h2>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UniversityId)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Major)
        </th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FirstName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LastName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UniversityId)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MajorId)
        </td>
    </tr>
Next

</table>
