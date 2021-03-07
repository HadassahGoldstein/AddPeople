$(() => {
    let count = 0;
    $("#add-row").on('click', function () {        
        count++;
        let html = `<div class="form-row mt-2" id=${count} >
            <div class="col">
                <input type="text" name="people[${count}].firstName" class="form-control" placeholder="First Name"/>
            </div >
            <div class="col">
                <input type="text" name="people[${count}].lastName" class="form-control" placeholder="Last Name" />
            </div>
            <div class="col">
                <input type="text" name="people[${count}].age" class="form-control" placeholder="age" />
            </div>
            <div class="col">
                <button class="btn btn-danger" data-id=${count} id="delete">Delete!</button>
            </div>
        </div >`;
        $("#rows").append(html);
        
    })
    $("#rows").on('click', '#delete', function () {
        let id = $(this).data('id'); 
        $(`#${id}`).remove();
    })
})