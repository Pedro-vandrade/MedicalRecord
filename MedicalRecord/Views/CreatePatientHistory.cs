/*using MedicalRecord.Models.Enums;

namespace MedicalRecord.Views
{
    public class CreatePatientHistory
    {

    }
}


@model PatientHistoryViewModel
@using MedicalRecord.Models.Enums
@using System.Reflection

@* ... form setup ... *@

<h3>Medical History</h3>

@* --- Multi-Select: Known Conditions --- *@
<div class= "form-group" >
    < label class= "control-label" > Known Conditions </ label >
    @foreach(DiseasesConditions condition in ViewBag.AllConditions)
    {
    // Skip the 'None' option for checkbox lists, unless explicitly needed
    if (condition == DiseasesConditions.None) continue;


        < div class= "form-check" >
            < input
                type = "checkbox"
                class= "form-check-input"
                name = "SelectedConditions" @* 👈 MUST match the ViewModel List name *@
                value="@condition" 
                id="@($"Condition_{condition}")"
                />
            < label class= "form-check-label" for= "@($"Condition_{ condition}
")" >
                @condition.ToString()
            </ label >
        </ div >
    }
    < span asp - validation -for= "SelectedConditions" class= "text-danger" ></ span >
</ div >

@*---Multi - Select: Surgical History(Same structure) ---*@
< div class= "form-group" >
    < label class= "control-label" > Surgical History </ label >
    @foreach(SurgicalProcedures surgery in ViewBag.AllSurgeries)
    {
    if (surgery == SurgicalProcedures.None) continue;


        < div class= "form-check" >
            < input
                type = "checkbox"
                class= "form-check-input"
                name = "SelectedSurgeries" @* 👈 MUST match the ViewModel List name *@
                value="@surgery" 
                id="@($"Surgery_{surgery}")"
                />
            < label class= "form-check-label" for= "@($"Surgery_{ surgery}
")" >
                @surgery.ToString()
            </ label >
        </ div >
    }
    < span asp - validation -for= "SelectedSurgeries" class= "text-danger" ></ span >
</ div >

@*---Single - Select: Exercise Activity(Dropdown) ---*@
< div class= "form-group" >
    < label asp -for= "ExerciseActivity" class= "control-label" ></ label >
    < select asp -for= "ExerciseActivity" class= "form-control" asp - items = "Html.GetEnumSelectList<Exercise>()" >
        < option value = "" > --Select Activity-- </ option >
    </ select >
</ div >*/