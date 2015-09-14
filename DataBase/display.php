<?php
    // Send variables for the MySQL database class.
    $database = mysql_connect('localhost', 'embryologie', '3Datlas') or die('Could not connect: ' . mysql_error());
    mysql_select_db('scores') or die('Could not select database');
 
    $query = "SELECT * FROM `scores` ORDER by `score` DESC LIMIT 10";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    $num_results = mysql_num_rows($result);  
 
   // echo "<table>"; // start a table tag in the HTML
	for($i = 0; $i < $num_results; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $row['name'].",".$row['score']."\n";
		// echo "<tr><td>". $row['name'] . "</td><td>" . $row['score']."</td></tr>\n";

    }
	//echo "</table>"; //Close the table in HTML
?>