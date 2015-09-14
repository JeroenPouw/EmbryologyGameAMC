<?php

    $username = $_REQUEST['username'];
	$password = $_REQUEST['password'];
	
     $db = mysql_connect('localhost', 'embryologie', '3Datlas') or die('Could not connect: ' . mysql_error());

      mysql_select_db('scores') or die('Could not select database');

     $query = "insert into users (username, password) values ('$username', '$password');";

     $result = mysql_query($query) or die('Query failed: ' . mysql_error());

          echo "registered";

         

?>