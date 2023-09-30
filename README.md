<div align="center">
<h1> RESSOURCES HUMAINES </h1>
<img src="https://laboiteaoutilsdesrh.com/wp-content/uploads/2022/05/metier-ressource-humaine--840x473.png">
<img src="https://badgen.net/badge/status/development/green" >
<br> <br>
Mini-projet entreprise 🎓 géstion des ressources humaines.
</div>

### Prérequis

- Dotnet 6 | 7
- PostgreSQL

## Configutaion de la base de donnée

modifier votre mot de passe et nom d'utilisateur dans

```
  S5-RH/appsettings.json
```
## Mise en marche
```
Dotnet run
```
### Commit et push

- Vérifier que vous êtes bien sur votre branche de travail
- Vérifier que vous avez bien `pull` la dernière version de la branche principale (afin d'éviter les conflits,
  cela permet de mettre à jour votre branche avec la dernière version de la branche principale et voir si votre code est
  compatible)
```
git pull origin <nom de la branche principale>
```
- Ajouter les fichiers modifiés
```
git add *
```
- Commiter les fichiers modifiés
```
git commit -m "message du commit"
```
- Pusher les fichiers modifiés
```
git push origin <nom de votre branche>
```
- Créer une `pull request` sur github pour demander la validation de votre code à integrer.
Pour éviter de pusher des fichiers sensibles et inutiles, il faut ajouter les fichiers à ignorer dans le fichier `.gitignore` à commencer par `venv` et `.env`
> Tenez à vérifier cela avant de pusher votre code

### Messages de commit
Pour les messages de commit, il faut commencer par le type de commit, suivi d'une description du commit :
- `feat`: pour les nouvelles fonctionnalités
- `fix`: pour les corrections
- `refactor`: pour les modifications de code qui n'ajoutent pas de fonctionnalités ou ne corrigent pas de bug
- `style`: pour les modifications qui n'apportent aucune altération de sens (indentation, mise en forme, ajout d'espace, renommage de variable, etc.)
- `test`: pour les ajouts de tests
- `perf`: pour les améliorations de performances
> exemple : `feat: add login feature`

### EntityFramework

syntaxe crud


Create
```
  using (var context = ApplicationDbContextFactory.Create())
  {
      context.Tests.Add(test);
      context.SaveChanges();
  }
```
Read
```
  using (var context = ApplicationDbContextFactory.Create())
  {
      var tests = context.Tests.ToList();
      return View(tests);
  }
```
Update
```
  using (var context = ApplicationDbContextFactory.Create())
  {
      context.Tests.Update(test);
      context.SaveChanges();
  }
```
Delete
```
  using (var context = ApplicationDbContextFactory.Create())
    {
        var test = context.Tests.FirstOrDefault(t => t.Id == id);
        if (test != null)
        {
            context.Tests.Remove(test);
            context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
```
