CODE_CHNAGES = getGitChanges()
pipeline{
	agent any
	stages{
		stage('Init') {
			when {expression {env.BRANCH_NAME.startsWith("${env.BRANCH_START_WTH}")}}
			steps {
				enableContentSecurityPolicyForReport()
				deleteDir()
				// cleanWs()
				echo 'initiating application nana branch ... ${env.BRANCH_NAME} '
			}
		}
		stage('build'){
			when{
				expression{
					env.BRANCHNAME == 'nana' && env.CODE_CHNAGES==true
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