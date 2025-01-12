# Vaabenbogen

Logging and Overview application for weapons-registry in Denmark, for companies in regards to sales, ownership and transfer of ownership.
Has functionality to export information for local danish governance in accordance to law.

## Description

The project consists of 2 applications, the provider(API) and consumer(UI), splitting responsibility for good practice.
The provider handles read/writes to DB in accordance to .NET core 8 standards.
The consumer handles UI interaction with workers wishing to register weapons and/or pull information from the DB

## Getting Started

### Dependencies

* Describe any prerequisites, libraries, OS version, etc., needed before installing program.
* ex. Windows 10

### Installing

* How/where to download your program
* Any modifications needed to be made to files/folders

### Executing program

* Install Visual Studio EF Core tools: 
```
Install-Package Microsoft.EntityFrameworkCore.Tools
```
* Add initialCreate script
```
Add-Migration InitialCreate
```
* Run initialCreate script
```
Update-Database
```

## Help

Any advise for common problems or issues.
```
command to run if program contains helper info
```

## Authors

Contributors names and contact info

ex. Dominique Pizzie  
ex. [@DomPizzie](https://twitter.com/dompizzie)

## Version History

* 0.2
    * Various bug fixes and optimizations
    * See [commit change]() or See [release history]()
* 0.1
    * Initial Release

## License

This project is licensed under the [NAME HERE] License - see the LICENSE.md file for details

## Acknowledgments

Inspiration, code snippets, etc.
* [awesome-readme](https://github.com/matiassingers/awesome-readme)
* [PurpleBooth](https://gist.github.com/PurpleBooth/109311bb0361f32d87a2)
* [dbader](https://github.com/dbader/readme-template)
* [zenorocha](https://gist.github.com/zenorocha/4526327)
* [fvcproductions](https://gist.github.com/fvcproductions/1bfc2d4aecb01a834b46)