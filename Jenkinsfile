def enableContentSecurityPolicyForReport(){
    script {System.setProperty("hudson.model.DirectoryBrowserSupport.CSP", "default-src 'self'; style-src 'self' 'unsafe-inline';");}
}

def  getGitChanges(){
	echo 'checking if code changed ...'
	def changes = false
    changes = currentBuild.changeSets.any { it.items.length > 0 }
	if (changes) {
          echo "Changes detected."
         // Add your actions here for when changes are detected
    } 
	else {
         echo "No changes detected."
	      // Add your actions here for when no changes are detected
    }
}

CODE_CHNAGES = getGitChanges()
pipeline{
	agent any
	stages{
		stage('Init') {
			when {expression {env.BRANCH_NAME.startsWith("nana")}}
			steps {
				//enableContentSecurityPolicyForReport()
				deleteDir()
				// cleanWs()
				script{
					def buildNumber = env.BUILD_NUMBER
                    echo "The current build number is: ${buildNumber}"
					def brnachName = env.BRANCH_NAME
					echo "branch name is ${brnachName}"

				}
			}
		}
		stage('build'){
			when{
				expression{
					env.BRANCHNAME == 'nana' //&& env.CODE_CHNAGES==true
				}
			}
			steps{
				echo 'building application nana branch...'
			}
		}
		stage('test'){
			steps{
				echo 'testing application ...'
			}
		}

		stage('deploy'){
			steps{
				echo 'deploying application ...'
			}
		}

	}

}