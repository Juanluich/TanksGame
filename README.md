# TankGame
 ![2024-02-22 02-15-28](https://github.com/Juanluich/TanksGame/assets/44837619/75d5d694-60c2-4c72-bdcd-fb3ef06daca7)

CONTROLS

Player functionality is exclusively with mouse:
Direction and force: mouse position on the screen.
Shot altitude: mouse wheel.
Projectile launch: right click.


PLAYER STRUCTURE

For the implementation of the test, we have started from the development of a class diagram, following the specifications, with the aim of giving shape to the structure and architecture that the project must follow at code level. 

In this way we get a much more precise guide of the steps to follow to achieve the requirements, and we have a mouldable and extendable line of work as the diagram itself, from which we can observe the evolution and/or features that the client could add in the future.
![1](https://github.com/Juanluich/TanksGame/assets/44837619/f6c163bd-effb-47b0-ba5f-21801b339349)

By means of the following class diagram we manage the behaviour of our player, breaking down each of the responsibilities of each action to a different class, thus complying with SOLID principles.

To highlight, ShootController is in charge of the management of the shot, performing the relevant mathematical calculations to calculate a parabola and interpret this parabola as the movement of the projectile towards the position of the mouse.
And PlayerTurn acts as an intermediary to notify the BattleSystem, our turn controller, of the actions we have performed.

TURN CONTROL
![2](https://github.com/Juanluich/TanksGame/assets/44837619/4931739c-cdcb-439b-ba10-05edd7f67583)

BattleSystem, which is in charge of managing both the player's and the enemy's actions, establishing the states of the game through an enum that dictates the rules of each turn.

On the other hand we have the enemy, which has a class structure almost similar to that of the player, where it has been possible to reuse functionalities, but with different notable aspects:

By means of a series of positions and a specific radius, we have defined a couple of random zones around the map, where the enemy will move randomly.
![3](https://github.com/Juanluich/TanksGame/assets/44837619/e8bab67d-3238-49f5-a3e8-5d17bf75bead)

In this way, we can more precisely control the range and movement of the enemy, according to our needs.

ENEMY STRUCTURE

On the other hand, a specific class that the enemy has, is EnemyAimingController, which calculates the precision of the shot according to the life it has, thus making the shots more precise as we subtract life, in order to make it a greater challenge.
![4](https://github.com/Juanluich/TanksGame/assets/44837619/1786449d-9c3e-49ff-8d76-e0ef351c946a)

As for the user interface and the hud, we have tried to make it as simple as possible, but trying to respect aspects of user experience, and adding some effects that provide feedback to the user.


AREAS FOR IMPROVEMENT

The code has tried to be structured to be done in the stipulated time, but it needs a refactoring of the systems to increase its scalability and structure.
In my opinion, I would change the shift and event access system to an event-driven architecture using ScriptableObjects, thus removing many of the dependencies between classes and making the system more robust and subject to change.

I would also add the progression of projectile strength by a small mechanic of a bar that increases and decreases over time, as we could say that the current version is in easy mode, as we will always hit the position of the shot.
