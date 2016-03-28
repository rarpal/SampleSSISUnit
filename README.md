# SampleSSISUnit
SSIS unit testing with SSISUnit framework in Visual Studio

The following is a list of test cases that we will be aiming to develop. These might seem trivial cases, but remember, we re trying to keep things simple as far as the subject matter is concerned and pay more attention to learning how SSISUnit work and how to integrate it with Visual Studios.
Test cases

1) Test Batch 1 new contacts:
After loading Batch 1, are there 4 new records in dim_Contacts

2) Test Batch 1 reload:
After reloading Batch 1, are there 4 records in dim_Contacts. Tests 2 to 4 should still pass

3) Test Batch 1 contact values:
After loading Batch 1, check record in dim_Contacts for contact number 2. The fields should match the following:
Name = 'Charls'
Telephone = '76569286717,76520989012'
Address = '1A Park Street, Bedford, BD7 9OP'
AddressDate = '1987-01-16'

4) Test Batch 1 de-duplication with new contact:
After loading Batch 1, check record in dim_Contacts for contact number 1. The fields should match the following:
Name = 'James'
Telephone = '78738742356,89389374351,76376318735'
Address = '154 Arvin Drive, Middlesex, MH5 7GD'
AddressDate = '2005-12-14'

5) Test Batch 1 null values:
After loading Batch 1, check record in dim_Contacts for contact number 3. The fields should match the following:
Name = 'Carol'
Telephone = ''
Address = '30 Church Road, Brighton, Essex, BR8 7UT'
AddressDate = '2000-09-02'

6) Test Batch 2 new contacts:
After loading Batch 2, are there a total of 5 records in dim_Contacts

7) Test Batch 2 de-duplication with update old contact:
After loading Batch 2, check record in dim_Contacts for contact number 2. The fields should match the following:
Name = 'Charls'
Telephone = '76569286717,76520989012,87293752635'
Address = '78 Station Road, Bedford, BD3 6TU'
AddressDate = '2001-04-15'


SSISUnit follows the traditional 3 stage xUnit structure of Setup, Test and Tear-down. So we will take this same approach in planning our test development.
 Test data

2 tab delimited text files as batch 1 and batch 2 which will be loaded in 2 load iterations.

 Batch 1: list of contacts with the following characteristics:
* At least 1 contact with no duplicated records
* At least 1 contact with duplicated records having different address with different address dates
* At least 1 contact with duplicated records having the same data in all fields

Batch 2:
* At least 1 new contact
* At least 1 existing contact with duplicated records having different address with different dates


