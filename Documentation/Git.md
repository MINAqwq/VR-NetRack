# Git
As you might have noticed, we use git as vcs (version control system)

This file can be used as small "cheat sheet" and give you an idea of how to work on this project with multiple people.

## Correctly obtaining the repo
DO NOT (seriously don't) download this repo over github by clicking on "Download as ZIP". Use Github Desktop or Git as shell program to clone this repo.

### Downloading Git
Github Desktop: https://desktop.github.com/ \
Git: https://git-scm.com/download/win/

Or if you are on a unix like operating system use your packet manager (brew, apt, pacman, ...)

GitHub Desktop is mostly self explaining so i will continue explaining how to do everything with plain git. Everything i show here can also be done in the GitHub Desktop GUI.

### Clone
Cloning is copying the repository from a server to your local device. Git repos are basically decentralized databases.
```sh
git clone <repo_url>
```
where repo_url is the link to the GitHub Repo. For example https://github.com/MINAqwq/VR-NetRack.

After successful cloning the repo you should have a new folder named like the Repo. You can now change to this folder.

## Commits

A Commit contains a "diff". A diff (difference) contains changes relative to the commit before (if there is one).

For example i have an init commit containing 2 code files:
```
example1.cs
example2.cs
```

When i modify example2.cs and make a commit out of it, the commit has no information about example1.cs, only what i have changed in example1.cs

## Branches
Git Repos have "branches". Branches are collections of commits.

In every git repo you have a master branch.

The master (or sometimes called main) branch should always contain a runnable and working version. Development should happen on sub branches, to prevent collision of commits.

For example:\
2 Persons clone the repo and work on the same branch.\
When Person 1 changes a file person 2 is also working on and makes a commit out of it, person 2 is behind without knowing. If person 2 now makes a commit with his changes without having person 1's commit, we have a big problem.

To be sure there are no collisions while working on a feature, every feature should have its own branch.

For example:
- master
- mina/cable
- pb/textures

Here we can perfectly see what feature gets developed on this branch and who is working on it right now. name/feature.

```sh
# this will print you the current branch you're on
git branch
```

### Create and move to a new branch

```sh
git branch <branch_name>
```

Where branch_name is the name of the branch lol

After creating you can move to the branch with

```sh
git checkout <branch_name> 
```

If you have unstaged changes you're unable to checkout. You have to stash or commit your changes.

## Show changed files
To see all files and their state just type in
```sh
git status
```

You will get a list with all modified, untracked or staged files (more on that later).

## Stage Files
When you create new files or change a tracked file (tracked means that git is "observing" this file) you need to stage it before you can create a commit.

Use the following command to track or stage a file
```sh
git add <path/to/file>
```

## Create a commit

### Configure Identity

If you use plain git you need to configure it so git knows who the commit made.

Normally it's as simple as
```
git config user.name <your_github_name>
git config user.email <your_github_email>
```
(you will find your commit email under https://github.com/settings/emails\
If you haven't overridden it, its looking like 635345+example@users.github.noreply.com)

But because github is github you also need to use github-cli to authorize your git instance. Because they disabled authorizing over https.

Security bla bla...

https://cli.github.com/ \
https://cli.github.com/manual/gh_auth_login

### Commit

After staging all changes you want to commit them. Use the following command to create a commit

```sh
git commit -m "commit message"
```

Or if you configured a default text editor with
```sh
git config core.editor <editor>
```

you can just type in
```
git commit
```

Then your editor will open and you can type in a commit message. Saving and Closing the buffer will result in a commit.

## Push to upstream

### Upstream/Remote

The remote is a repository on a server used to sync all changes between different devices. The main remote is mostly called origin. When you clone a repo from a server, origin will be this server by default.

### Pushing

Pushing is the opposite of pulling. We will send our local changes to the remote host and make them available for other people.

```sh
git push <remote> <your_branch>
```

If we worked on the branch mina/example and want to push the changes to the remote we cloned the repo from we type in

```sh
git push origin mina/example
```

## Pull changes

Let's say someone had a local branch called pb/feature1 and you have to work on it now. After everyone had committed and pushed their changes you can pull the information about that branch and all new changes by:

1. checking out to the master
```sh
git checkout master
``` 

2. Pulling all newest changes
```sh
git pull origin master
```

3. Checking out to the new branch
```sh
git checkout pb/feature1
```

## Good to know

Stuff good to know for a professional and mentally 
destructive git workflow.

### Fetch

Fetching is like pulling but without applying changes to the branch you're on. It has the information, but it won't use them. Always good to try if pulling is giving you weird errors.

```sh
git fetch
```

### Stashing

The Stash is a local stack where you can save changes you're to lazy to commit before changing branches.

The following commands will remove all uncommitted changes and save them on the stack.
```sh
git stash
```

If you want to bring them back just use
```sh
git stash pop
```

This will remove them from to stack. If you want to be save use
```git
git stash apply
```
but if you run into merge conflicts it won't remove the changes after a pop so using stash pop is fine.

### Force Push
The HEAD is the latest commit on a branch. Normally you cant push commits that not base on the HEAD.

BUT\
if you're completely insane and think it's a good idea to throw away all common sense and override the HEAD you can use
```sh
# -f == --force
git push <remote> <branch> -f
```

The are only a few cases where its okay to force push. Like the 2 i cover now.

### Amend

An amend is basically overriding your last commit last commit + other changes.

Let's say you committed changes and then you're like "Oh wait, i forgot a file" or "I have to change something but don't want to make an extra commit for it"

Then amending is your friend.

stage your changes with git add as normally and then use
```sh
git commit -m "new message" --amend
```

As the lazy mf i am, i prefer
```sh
git commit --amend --no-edit
```
This will just use the old commit message hehe.

But now our HEAD has another hash and does not base on the HEAD on the upstream. Git is not amused. But we are superior developer and know we never do mistakes and we can override the HEAD without breaking the repo.

So we do a force push (otherwise you will get funny error)

### Rebase
I hope you never have to rebase your branch. But just in case you have to:

```sh
git rebase <branch>
```

What it does? it will rebuild your branch with the commits from another branch to make them base on the same commits. If you want to merge your commits into the master, but the master has 2 commits you don't have (your 2 commits behind in git language), you need to get this 2 commits into your branch.

After pulling and checking you're local changes are up to date, a
```sh
git rebase master
```
will solve all your problems. Now your latest commit after your own commits should be the 2 from the master. Now you can merge without weird conflicts.

BUT\
There are few cases where you will get merge conflicts. Git will guide you through them but its really overloading if you encounter them for the first time. Only God and Google can help you now.

## Merging
You should only merge branches over GitHub:\
-> [aNd HoW?](GitHubMerge.md)
