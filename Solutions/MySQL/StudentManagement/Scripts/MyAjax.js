// Function to load students when a course is selected
function loadStudents() {
    var courseId = document.getElementById('<%= ddlCourses.ClientID %>').value;
    var messageLabel = document.getElementById('<%= lblMessage.ClientID %>');
    var loadingDiv = document.getElementById('loading');

    if (courseId == "0") {
        messageLabel.style.color = "red";
        messageLabel.textContent = "Please select a course.";
        return;
    }

    messageLabel.textContent = ""; // Clear previous message
    loadingDiv.style.display = "block"; // Show loading message

    // Create the AJAX request
    fetch('AttendanceManagement.aspx/LoadStudents', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ courseId: courseId })
    })
        .then(response => response.json())
        .then(data => {
            loadingDiv.style.display = "none"; // Hide loading message

            if (data.success) {
                // Populate GridView with data
                var gridView = document.getElementById('<%= gvStudents.ClientID %>');
                var rows = '';
                data.students.forEach(student => {
                    rows += `<tr><td>${student.StudentId}</td><td>${student.Name}</td><td><input type="checkbox" /></td></tr>`;
                });
                gridView.querySelector('tbody').innerHTML = rows;
            } else {
                messageLabel.style.color = "red"; 
                messageLabel.textContent = data.message;
            }
        })
        .catch(error => {
            loadingDiv.style.display = "none";
            messageLabel.style.color = "red";
            messageLabel.textContent = "Error loading students: " + error.message;
        });
}

// Function to submit attendance
function submitAttendance() {
    var courseId = document.getElementById('<%= ddlCourses.ClientID %>').value;
    var messageLabel = document.getElementById('<%= lblMessage.ClientID %>');
    var loadingDiv = document.getElementById('loading');

    if (courseId == "0") {
        messageLabel.style.color = "red";
        messageLabel.textContent = "Please select a course.";
        return;
    }

    loadingDiv.style.display = "block"; // Show loading message

    // Prepare attendance data
    var attendanceData = [];
    var gridRows = document.getElementById('<%= gvStudents.ClientID %>').querySelectorAll('tr');
    gridRows.forEach(row => {
        var studentId = row.cells[0].textContent;
        var isPresent = row.querySelector('input[type="checkbox"]').checked;
        attendanceData.push({ studentId: studentId, isPresent: isPresent });
    });

    // Create the AJAX request
    fetch('AttendanceManagement.aspx/SubmitAttendance', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ courseId: courseId, attendanceData: attendanceData })
    })
        .then(response => response.json())
        .then(data => {
            loadingDiv.style.display = "none"; // Hide loading message
            messageLabel.style.color = data.success ? "green" : "red";
            messageLabel.textContent = data.message;
        })
        .catch(error => {
            loadingDiv.style.display = "none";
            messageLabel.style.color = "red";
            messageLabel.textContent = "Error submitting attendance: " + error.message;
        });
}

