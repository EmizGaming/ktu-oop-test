# KTU OOP Template

This a template repository for autoatically generating report PDF files and
upload it to moodle.

This template combines 3 tools for achieving this task:
* [RokasPuzonas/ktu-oop-report-generator](https://github.com/RokasPuzonas/ktu-oop-report-generator)
* [RokasPuzonas/ktu-moodle-assignment-upload](https://github.com/RokasPuzonas/ktu-moodle-assignment-upload)
* [GitHub Actions](https://github.com/features/actions)

The generator for creating the report, the uploader for uploading that report
and GitHub Actions to glue the generator and uploader together so they would be
run whenever a change is uploaded to GitHub.

## Guide

This guide will assume you know absuletely NOTHING about Git/GitHub, the reason
being is because the people I expect to try to use this template all don't know
anything about Git and GitHub.

**If at any point you are confused about how a file should look, I have a
personal repository which uses this template: [RokasPuzonas/OOP-Labs](https://github.com/RokasPuzonas/OOP-Labs)!**

### Create a repository from this template

#### Create a GitHub account

If you still don't have a GitHub account you will need one to use Github
Actions. I won't be explaining this part in details, because it is really
simple and has already been explained plenty of times.
[Getting started with your GitHub Account](https://docs.github.com/en/get-started/onboarding/getting-started-with-your-github-account)

#### Learn the basics of GitHub and Git

This too, I won't go into any details, but I expect you to at least know how to
upload your changes and files to GitHub.

Here is a couple of good resources for starting:
* [GitHub flow](https://docs.github.com/en/get-started/quickstart/github-flow)
* [Git Overview - Computerphile](https://www.youtube.com/watch?v=92sycL8ij-U)
* [About Git](https://docs.github.com/en/get-started/using-git/about-git)

#### Create a repository from this template

This ain't too difficult you just click the green "Use this template" button at
the top. But here's a detailed guide with you are having trouble
[Creating a repository from a template](https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template).

### Upload C# projects to repository

I will assume that you didn't skip the earlier steps of learning the basics of
Git and GitHub and know you to upload folders. Moving on...

**Now this is important!!! A C# project is only the folder which contains a 
`.csproj` file!**

I am mentioning this, because terminology is REALLY important.

It means that if you are messy and don't store your project neatly you could
run in to some dumb mistakes later on, I have seen it happen. For example, let's say youre repository
structure looks like this:
```
.
├── AlgorithmsProject
│   └── Project
│       └── Project.csproj
├── DataStructure
│   ├── DataStructure.sln
│   ├── DogsAndCats
│   │   └── DogsAndCats.csproj
│   ├── Project
│   │   └── Project.csproj
│   └── Sports
│       └── Sports.csproj
├── README.md
└── report.toml
```

You might wanna say that `./AlgorithmsProject` is a project, but it dosen't
directly contain a `.csproj` file, `./AlgorithmsProject/Project` is the C#
project folder. Now you might ask what are the `./DataStructure` and
`./AlgorithmsProject` folders called and you might say solutions! You would be
only half correct, `./AlgorithmsProject` is not a solution, it does not have a
`.sln` file, it's only a sub-folder.

So in this scenario the C# projects are: `./AlgorithmsProject/Project`,
`./DataStructure/DogsAndCats`, `./DataStructure/Sports`,
`./DataStructure/Project`.

### Upload tests to each C# project

One of the reports requirements on gettings a perfect grade is to have at least
2 tests (from my experience). This is done by creating a folder called `tests`
in each project that you want (`tests` is a folder name I picked and can be
changed). Each sub-folder in the tests folder is a test. And it contains files
which will be provided to the program when it is run.
```
.
├── Project.csproj
└── tests
    ├── 1
    │   ├── Data1.csv
    │   └── Data2.csv
    └── 2
        ├── Data1.csv
        └── Data2.csv
```

**This is important! the tests folder name is case-sensitive. tests != Tests**

This will work in most cases when all of your data comes from files. But
sometimes you might need to enter some data through the console, that's where
the special `stdin.txt` file comes in. It is a replacement of you manually
typing stuff into the console. The text from this file gets entered line by
line into the program. Here's how such a project would look:
```
.
├── Project.csproj
└── tests
    ├── 1
    │   ├── Data1.csv
    │   ├── Data2.csv
    │   └── stdin.txt
    └── 2
        ├── Data1.csv
        ├── Data2.csv
        └── stdin.txt
```

### Setup [report.toml](./report.toml)

This file provides the generator with information which it can't extrapolate
from the projects, like your name, the lecturers name and other things.

Now before we even starting entering anything you should be familiar with the
[TOML](https://toml.io/en/) file format. If not, check it out it's a really
simple and in my opinion a very user friendly format.

If at anypoint you want a reference of how things should look, take a look
[here](https://github.com/RokasPuzonas/OOP-Labs/blob/main/report.toml).

1. Update `title`
This is the text that is shown on the first page right in the middle. For
example:
```toml
title = "Objektinis programavimas I (P175B118)"
```

2. Update `student.name`, `student.gender`
This is also shown on the first page, slighly below the title.
Don't forget to update the gender!
```toml
student = { name = "Studento Bob Bobby BB-1/2", gender = "male" }
```

3. Update `lecturer.name`, `lecturer.gender`
This is shown on the first page just like student, slighly below the title.
Don't forget to update the gender too!
```toml
lecturer = { name = "lekt. Alice Alison", gender = "female" }
```

4. Setup sections

At first you might not have any projects any, but you can still setup the
report by adding empty sections. Like this:
```toml
[[sections]]
title = "Algorithms"

[[sections]]
title = "Data Structure"
```

**The ordering of sections matters. It will be in the same order as in the
generated report.**

As time goes on you will complete projects and your sections will start to look
like this:
```toml
[[sections]]
title = "Algorithms"
project = "AlgorithmsProject/Project"
problem = """
Blah, blaaah, bla bla blaaahhh...
details, details, details...
"""

[[sections]]
title = "Data Structure"
project = "DataStructure/Project"
problem = """
Blah, blaaah, bla bla blaaahhh...
details, details, details...
"""
```

Now both sections, have projects assigned to them, that means that the source
code from the project will placed into the report. And if the project also has
tests they will be executed and put into the report. And the field `problem` is
just the explanation of the assignment given.

If you want to create a bullet list in the `problem` field use "*" instead of
dots:
```
* point 1
* point 2
* point 3
```

**Now I want to repeat this again! Because it is really easy to this up! The
field `project` in each section must direct to a C# project.**

I explained how a path to a C# project should look like earlier [here](#upload-tests-to-each-c-project).

### Setup [generate-and-upload.yml](.github/workflows/generate-and-upload.yml)

Now before doing anything you need to know what a `.yml` file is.
You read about what it is [here](https://www.redhat.com/en/topics/automation/what-is-yaml).
But the important thing here that you need to know is that uses indentation to
structure data, similar to python. If you mix up spaces and tabs, it will be
angry and won't work. **Be careful with spacing!**

[Here](https://github.com/RokasPuzonas/OOP-Labs/blob/main/.github/workflows/generate-and-upload.yml)
is a personal reference of how things should look.

1. Find out your moodle assignment id.
You can go [here](https://github.com/RokasPuzonas/ktu-moodle-assignment-upload#usage)
to find out how this in the original repository. It's step 5 in the usage guide.
And you update it here in the `generate-and-upload.yml` file:
```yml
env:
  ASSIGNMENT_ID: -1 # <---------------
  MOODLE_FILENAME: BB-1-2_Bob_Bobby.pdf
  CONFIG_FILENAME: report.toml
  DOTNET_VERSION: 3.0.103
```

2. Update moodle filename
This variable determines how will the file be named, when uploaded to moodle.
```yml
env:
  ASSIGNMENT_ID: -1
  MOODLE_FILENAME: BB-1-2_Bob_Bobby.pdf # <---------------
  CONFIG_FILENAME: report.toml
  DOTNET_VERSION: 3.0.103
```

3. Provide KTU AIS credentials
This is so that the script can upload the file using your account. We will be
using GitHub secrets so only the owner of the repository could see the
credentials. You wouldn't want everyone to be able to see your credentials if
you made your repository public. There is already a guide on how to do this
[here](https://docs.github.com/en/actions/security-guides/encrypted-secrets#creating-encrypted-secrets-for-a-repository).

You will need to create 2 secrets `KTU_USERNAME` and `KTU_PASSWORD`, which will
hold your username and password.

4. Uncomment trigger
In the `generate-and-upload.yml` file there is one commented section, you will
need to uncomment it. It should look something like this:
```yml
on:
  workflow_dispatch:
  push:
    branches: [ main ]
    paths:
      - 'report.toml' # This should be the same as CONFIG_FILENAME
      - 'path/to/project/used/in/report/**'
      - 'another/path/if/for/another/project/**'
```

Now that thing is to whitelist the files which trigger the generator, because
we woulnd't want to re-run the generator when a project not in a report
changes. The generator is pretty fast so this technically is not required, but
reuploading the same report 10 times in a row is unnecessary. So that means
`on.push.paths` should contain a list of all projects used in `report.toml`
plus the actual `report.toml` file. For example:
```yml
on:
  workflow_dispatch:
  push:
    branches: [ main ]
    paths:
      - 'report.toml' # This should be the same as CONFIG_FILENAME
      - 'AlgorithmsProject/Project'
      - 'DataStructure/Project'
```

**Remember to always update this list when you add a new project to
`report.toml`**

### Profit!
You are done!
Congrats!
Now you can delete this README file and write your own from here.

