
Description:
This is a C# console application that manages a photo gallery using a circular doubly linked list data structure. The app allows you to add, delete, navigate (next/previous), display, count, and sort photos by their added date.

Key Features:
Add Photos: Add new photos with name, path, and date added.

Delete Photos: Delete the current photo and update the current pointer accordingly.

Navigate Photos: Move to the next or previous photo in a circular manner.

Display Photos: Show all photos with their details.

Count Photos: Get the total number of photos in the gallery.

Sort Photos: Display photos sorted by their date added (ascending or descending).

Clear Gallery: Remove all photos from the gallery at once.

Calculate Storage Size: Compute the storage size of each photo based on its dimensions and bits per pixel.

Implementation Details:
Uses a Circular Doubly Linked List to store and navigate photos efficiently.

Each photo is represented by a Photo class containing name, path, date added, dimensions (length and width), and bits per pixel.

Calculates storage size based on photo dimensions and bits per pixel.

Photo nodes are linked with prev and next references for easy traversal.

Interactive console commands allow managing the gallery dynamically.

Usage:
Run the program and enter one of the following commands when prompted:

add — Add a new photo.

delete — Delete the current photo.

display — Display all photos.

next — Move to the next photo.

previous — Move to the previous photo.

count — Show total number of photos.

sort — Display photos sorted by date added.

clear — Clear all photos from the gallery.

exit — Exit the application.

System Requirements:
.NET Framework or .NET Core environment for running C# applications.

No external libraries required.

Notes:
Photo name and path are entered manually by the user.

